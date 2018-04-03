import { Component, OnInit } from '@angular/core';
import {Prato} from '../prato.model'
import {Restaurante} from '../../restaurantes/restaurante.model'
import {RestauranteService} from '../../restaurantes/restaurantes.service'

import {PratoService} from '../pratos.service'
import {FormGroup, FormBuilder, Validators, AbstractControl} from '@angular/forms'
import {Router} from '@angular/router'

@Component({
  selector: 'mt-cadastrar',
  templateUrl: './cadastrar.component.html'
})
export class CadastrarPratoComponent implements OnInit {
  pratoForm: FormGroup
  //prato:Prato = {descricao:""}
   restaurantes:Restaurante[]
  constructor(private pratoService: PratoService,private restauranteService: RestauranteService, private router: Router,  private formBuilder: FormBuilder) { }

  ngOnInit() {    
    this.pratoForm = this.formBuilder.group({
      descricao: this.formBuilder.control('', [Validators.required, Validators.minLength(60)]),
      restauranteId: this.formBuilder.control('',[Validators.required] ),
      preco: this.formBuilder.control('',[Validators.required] )
    }
    )
    
    
    //Busca lista de restaurantes
    this.restauranteService.restaurantes().subscribe(restaurantes => this.restaurantes = restaurantes)
    //console.log(this.restaurantes)
  }


  
  salvar(prato: Prato){
    this.pratoService.salvar(prato).subscribe( (prato: Prato) => {
        this.router.navigate(['/pratos'])       
    })
      
    
  }

   excluir(prato: Prato){
    this.pratoService.excluir(prato).subscribe( (prato: Prato) => {
        this.router.navigate(['/pratos'])       
    })
      
    
  }


}
