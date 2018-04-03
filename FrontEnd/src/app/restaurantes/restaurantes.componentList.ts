import { Component, OnInit, Input } from '@angular/core';
import {Restaurante} from './restaurante.model'
import {RestauranteService} from './restaurantes.service'
import {Router} from '@angular/router'

@Component({
  selector: 'mt-restaurantes',
  templateUrl: './restaurantes.componentList.html'
})
export class RestaurantesComponent implements OnInit {
  
  restaurantes:Restaurante[]
  filter = {descricao:""}
  constructor(private restauranteService: RestauranteService, private router: Router) { }

  ngOnInit() {
    this.restauranteService.restaurantes()
    .subscribe(restaurantes => this.restaurantes = restaurantes)
  }

   excluir(restaurante: Restaurante){
   
    this.restauranteService.excluir(restaurante).subscribe( (restaurante: Restaurante) => {
         this.restauranteService.restaurantes().subscribe(restaurantes => this.restaurantes = restaurantes)
    })
  }

 

}
