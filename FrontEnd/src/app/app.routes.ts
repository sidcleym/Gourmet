import {Routes} from '@angular/router'

import {HomeComponent} from './home/home.component'
import {RestaurantesComponent} from './restaurantes/restaurantes.componentList'
import {CadastrarRestauranteComponent} from './restaurantes/cadastrar/cadastrar.component'
import {PratosComponent} from './pratos/pratos.componentList'
import {CadastrarPratoComponent} from './pratos/cadastrar/cadastrar.component'
import {EditarRestauranteComponent} from './restaurantes/editar/editar.component'
import {EditarPratoComponent} from './pratos/editar/editar.component'


export const ROUTES: Routes =[
    {path: '',component: HomeComponent},    
    {path: 'restaurantes',component: RestaurantesComponent},
    {path: 'restaurantes/editar/:id',component: EditarRestauranteComponent},
    {path: 'restaurantes/cadastrar',component: CadastrarRestauranteComponent},
    {path: 'pratos',component: PratosComponent},
    {path: 'pratos/editar/:id',component: EditarPratoComponent},
    {path: 'pratos/cadastrar',component: CadastrarPratoComponent}
]