import { Component, OnInit } from '@angular/core';
import {Restaurante} from '../restaurante.model'
import {RestauranteService} from '../restaurantes.service'
import {ActivatedRoute, Router} from '@angular/router'
import {FormGroup, FormBuilder, Validators, AbstractControl} from '@angular/forms'

@Component({
  selector: 'mt-editar',
  templateUrl: './editar.component.html'
})
export class EditarRestauranteComponent implements OnInit {
restauranteForm: FormGroup
restaurante: Restaurante

constructor(private activatedRouter:ActivatedRoute,private router:Router, private restauranteService: RestauranteService, private formBuilder: FormBuilder) { }

  ngOnInit() {
     
    this.restauranteService.getById(this.activatedRouter.snapshot.params['id'])
      .subscribe(restaurante =>this.restaurante = restaurante)

    this.restauranteForm = this.formBuilder.group({
      id: this.formBuilder.control(0, [Validators.required,  Validators.minLength(1)]),
      descricao: this.formBuilder.control('', [ Validators.required,  Validators.minLength(60)])
    
    })
    

  }

  atualizar(restaurante: Restaurante){
    restaurante.id = this.restaurante.id
     console.log("atualizar:"+restaurante.id);
     this.restauranteService.atualizar(restaurante)
     .subscribe((restaurante: Restaurante) => {
        this.router.navigate(['/restaurantes'])       
    })

  }
}
