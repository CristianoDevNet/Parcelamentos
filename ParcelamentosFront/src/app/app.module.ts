import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import localePtBr from '@angular/common/locales/pt';
import { registerLocaleData } from '@angular/common';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TelaInicialComponent } from './tela-inicial/tela-inicial.component';
import { AdicionarProdutoComponent } from './adicionar-produto/adicionar-produto.component';
import { AdicionarOrcamentoComponent } from './adicionar-orcamento/adicionar-orcamento.component';

import { SlimLoadingBarModule } from "ng2-slim-loading-bar";

import { ReactiveFormsModule } from "@angular/forms";

import { HttpClientModule } from "@angular/common/http";

import { ProdutoService } from "./produto.service";

import { CurrencyMaskModule } from "ng2-currency-mask";

registerLocaleData(localePtBr);

@NgModule({
  declarations: [
    AppComponent,
    TelaInicialComponent,
    AdicionarProdutoComponent,
    AdicionarOrcamentoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SlimLoadingBarModule,
    ReactiveFormsModule,
    HttpClientModule,
    CurrencyMaskModule
  ],
  providers: [
    ProdutoService,
    {
      provide: LOCALE_ID, useValue: 'pt-BR'
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
