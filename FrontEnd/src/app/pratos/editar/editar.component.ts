import { Component, OnInit } from '@angular/core';
import {RestauranteService} from '../../restaurantes/restaurantes.service'
import {Restaurante} from '../../restaurantes/restaurante.model'
import {Prato} from '../prato.model'

import {PratoService} from '../pratos.service'
import {FormGroup, FormBuilder, Validators, AbstractControl} from '@angular/forms'
import {Router, ActivatedRoute} from '@angular/router'


@Component({
  selector: 'mt-editar',
  templateUrl: './editar.component.html'
})
export class EditarPratoComponent implements OnInit {

    pratoForm: FormGroup
  //prato:Prato = {descricao:""}
   restaurantes:Restaurante[]
   prato : Prato = {id:0,descricao:"",restauranteId:0, preco:0, restaurante:undefined }
  constructor(private pratoService: PratoService,private restauranteService: RestauranteService, private router: Router, private activatedRouter: ActivatedRoute, private formBuilder: FormBuilder) { }

  ngOnInit() {
        this.pratoService.getById(this.activatedRouter.snapshot.params['id'])
      .subscribe(prato =>this.prato = prato)

     this.pratoForm = this.formBuilder.group({
      id: this.formBuilder.control(0, [Validators.required]),
      descricao: this.formBuilder.control('', [Validators.required, Validators.minLength(60)]),
      restauranteId: this.formBuilder.control('',[Validators.required] ),
      preco: this.formBuilder.control('',[Validators.required] )
    })

    //Busca lista de restaurantes
    this.restauranteService.restaurantes().subscribe(restaurantes => this.restaurantes = restaurantes)
  }



    atualizar(prato: Prato){
      //prato.id = this.prato.id
      //prato.restauranteId = (prato.restauranteId) ? prato.restauranteId : this.prato.restauranteId;
      //prato.preco         = (prato.preco>0) ? prato.preco : this.prato.preco;
      prato.restaurante = null
      console.log("atualizar:"+prato.restauranteId);
      this.pratoService.atualizar(prato)
      .subscribe((prato: Prato) => {
        this.router.navigate(['/pratos'])       
     })
    }


}
