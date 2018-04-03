import {Injectable} from '@angular/core'
import {Http, Headers, RequestOptions} from '@angular/http'
import {Observable} from 'rxjs/Observable'
import 'rxjs/add/operator/map'
import 'rxjs/add/operator/catch'

import {Prato} from "./prato.model"
import {GOURMET_API} from '../app.api'
import {ErrorHandler} from '../app.error-handler'

@Injectable()
export class PratoService{
    constructor(private http: Http){}

    pratos(): Observable<Prato[]> {
        return this.http.get(`${GOURMET_API}/pratos`)
        .map(response => response.json())
        .catch(ErrorHandler.handleError)

    }

    salvar(prato: Prato) {
        const headers = new Headers()
        headers.append('Content-Type', 'application/json')
        console.log("service:"+prato)
        return this.http.post(`${GOURMET_API}/pratos`
                              ,JSON.stringify(prato)
                              ,new RequestOptions({headers: headers}))
        .map(response => response.json())
        .catch(ErrorHandler.handleError)
    }

     atualizar(prato: Prato) {
        const headers = new Headers()
        headers.append('Content-Type', 'application/json')
        console.log("service:"+prato)
        return this.http.put(`${GOURMET_API}/pratos/`+prato.id
                              ,JSON.stringify(prato)
                              ,new RequestOptions({headers: headers}))
        .map(response => response.json())
        .catch(ErrorHandler.handleError)

    }

    getById(id: number): Observable<Prato>{
        
        console.log("serviceget by id: "+id)
        return this.http.get(`${GOURMET_API}/pratos/`+id
                            )
        .map(response => response.json())
        .catch(ErrorHandler.handleError)
    }

    excluir(prato: Prato) {
       
        const headers = new Headers()
        headers.append('Content-Type', 'application/json')
        console.log("service:"+prato)
        return this.http.delete(`${GOURMET_API}/pratos/`+prato.id                              
                              ,new RequestOptions({headers: headers}))
        .map(response => response.json())
        .catch(ErrorHandler.handleError)
    }

}