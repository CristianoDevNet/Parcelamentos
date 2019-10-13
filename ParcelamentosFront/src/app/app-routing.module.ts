import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TelaInicialComponent } from "./tela-inicial/tela-inicial.component";
import { AdicionarProdutoComponent } from "./adicionar-produto/adicionar-produto.component";
import { AdicionarOrcamentoComponent } from "./adicionar-orcamento/adicionar-orcamento.component";

const routes: Routes = [
  {
    path: 'telaInicial',
    component: TelaInicialComponent
  },
  {
    path: 'adicionarProduto',
    component: AdicionarProdutoComponent
  },
  {
    path: 'adicionarOrcamento',
    component: AdicionarOrcamentoComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
