import { Component, OnInit } from '@angular/core';
import {Restaurante} from '../restaurante.model'
import {RestauranteService} from '../restaurantes.service'
import {FormGroup, FormBuilder, Validators, AbstractControl} from '@angular/forms'
import {Router,ActivatedRoute} from '@angular/router'

@Component({
  selector: 'mt-cadastrar',
  templateUrl: './cadastrar.component.html'
})
export class CadastrarRestauranteComponent implements OnInit {
  restauranteForm: FormGroup
  restaurante:Restaurante

  constructor( private restauranteService: RestauranteService, private router: Router,  private formBuilder: FormBuilder) { }

  ngOnInit() {
    //this.activatedRouter.snapshot.params['id'];
     //if(this.restaurante)
     this.restauranteForm = this.formBuilder.group({descricao: this.formBuilder.control('', [ Validators.required,  Validators.minLength(60)])})
  }


  
  salvar(restaurante: Restaurante){
    this.restauranteService.salvar(restaurante).subscribe( (restaurante: Restaurante) => {
        this.router.navigate(['/restaurantes'])       
    })
      
    
  }

}
