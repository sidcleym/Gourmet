import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { FormsModule,ReactiveFormsModule  } from '@angular/forms';

import {ROUTES} from './app.routes';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { RestaurantesComponent } from './restaurantes/restaurantes.componentList'
import { RestauranteService } from './restaurantes/restaurantes.service';
import { PratoService } from './pratos/pratos.service';
import { PratosComponent } from './pratos/pratos.componentList';
import { CadastrarRestauranteComponent } from './restaurantes/cadastrar/cadastrar.component';
import { CadastrarPratoComponent } from './pratos/cadastrar/cadastrar.component';
import { EditarRestauranteComponent } from './restaurantes/editar/editar.component';
import { EditarPratoComponent } from './pratos/editar/editar.component';
import { RestauranteFilterPipe } from './shared/restaurante-filter.pipe'
import {PratoFilterPipe } from './shared/prato-filter.pipe'


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,    
    RestaurantesComponent,
    PratosComponent,
    CadastrarRestauranteComponent,
    CadastrarPratoComponent,
    EditarRestauranteComponent,
    EditarPratoComponent,
    RestauranteFilterPipe,
    PratoFilterPipe
  ],
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(ROUTES)
  ],
  providers: [RestauranteService, PratoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
