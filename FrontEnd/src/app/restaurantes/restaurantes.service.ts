import {Injectable} from '@angular/core'
import {Observable} from 'rxjs/Observable'
import {Http, Headers, RequestOptions} from '@angular/http'
import 'rxjs/add/operator/map'
import 'rxjs/add/operator/catch'

import {Restaurante} from "./restaurante.model"
import {GOURMET_API} from '../app.api'
import {ErrorHandler} from '../app.error-handler'

@Injectable()
export class RestauranteService{
    constructor(private http: Http){}

    restaurantes(): Observable<Restaurante[]> {
        return this.http.get(`${GOURMET_API}/restaurantes`)
        .map(response => response.json())
        .catch(ErrorHandler.handleError)

    }

    salvar(restaurante: Restaurante) {
        const headers = new Headers()
        headers.append('Content-Type', 'application/json')
        console.log("service:"+restaurante)
        return this.http.post(`${GOURMET_API}/restaurantes`
                              ,JSON.stringify(restaurante)
                              ,new RequestOptions({headers: headers}))
        .map(response => response.json())
        .catch(ErrorHandler.handleError)

    }
    atualizar(restaurante: Restaurante) {
        const headers = new Headers()
        headers.append('Content-Type', 'application/json')
        console.log("service:"+restaurante)
        return this.http.put(`${GOURMET_API}/restaurantes/`+restaurante.id
                              ,JSON.stringify(restaurante)
                              ,new RequestOptions({headers: headers}))
        .map(response => response.json())
        .catch(ErrorHandler.handleError)

    }
    getById(id: number): Observable<Restaurante>{
        
        console.log("serviceget by id: "+id)
        return this.http.get(`${GOURMET_API}/restaurantes/`+id
                            )
        .map(response => response.json())
        .catch(ErrorHandler.handleError)
    }

    excluir(restaurante: Restaurante) {
       
        const headers = new Headers()
        headers.append('Content-Type', 'application/json')
        console.log("service:"+restaurante)
        return this.http.delete(`${GOURMET_API}/restaurantes/`+restaurante.id                              
                              ,new RequestOptions({headers: headers}))
        .map(response => response.json())
        .catch(ErrorHandler.handleError)
    }

}