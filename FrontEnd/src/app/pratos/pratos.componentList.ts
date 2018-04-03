import { Component, OnInit, Input } from '@angular/core';
import {Prato} from './prato.model'
import {PratoService} from './pratos.service'
import {Router} from '@angular/router'

@Component({
  selector: 'mt-pratos',
  templateUrl: './pratos.componentList.html'
})
export class PratosComponent implements OnInit {
  
  pratos:Prato[]
  filter = {descricao:""}
  constructor(private pratoService: PratoService, private router: Router) { }

  ngOnInit() {
    this.pratoService.pratos()
    .subscribe(pratos => this.pratos = pratos)
  }

  excluir(prato: Prato){
   
    this.pratoService.excluir(prato).subscribe( (ret: Prato) => {
        this.pratoService.pratos().subscribe(pratos => this.pratos = pratos)      
    })
  }

}
