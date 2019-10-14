import { Component, OnInit } from '@angular/core';

import { FormGroup, FormBuilder, Validators } from "@angular/forms";

import { ProdutoService } from "../produto.service";
import Produto from 'src/Models/Produto';
import Orcamento from 'src/Models/Orcamento';
import { getLocaleNumberFormat, NumberFormatStyle } from '@angular/common';

@Component({
  selector: 'app-adicionar-produto',
  templateUrl: './adicionar-produto.component.html',
  styles: []
})
export class AdicionarProdutoComponent implements OnInit {

  angForm: FormGroup;

  novoProduto: Produto;

  orcamentoIntegrado: Orcamento;

  constructor(private fb: FormBuilder, private ps: ProdutoService) 
  { 
    this.createForm();

    this.novoProduto = 
    { 
      Id: 0,
      Nome: null,
      Orcamentos: null
    };

    this.orcamentoIntegrado = 
    {
      Id: 0,
      ProdutoId: 0,
      ValorBase: 0,
      JurosMes: 0,
      QtdParcelas: 0,
      PrimeiroVencimento: null,
      Produto: null,
      Parcelas: null
    };
  }

  createForm()
  {
    this.angForm = this.fb.group({
      NomeProduto: ['', Validators.required],
      ValorBase: [''],
      JurosMes: [''],
      QtdParcelas: [''],
      PrimeiroVencimento: ['']
    })
  }

  adicionarProduto(nomeProduto, valorBase, jurosMes, qtdParcelas, primeiroVencimento)
  {
    this.novoProduto.Nome = nomeProduto;

    this.orcamentoIntegrado.ValorBase = Number(valorBase);

    this.orcamentoIntegrado.JurosMes = Number(jurosMes.replace("%", ""));

    this.orcamentoIntegrado.QtdParcelas = Number(qtdParcelas);

    this.orcamentoIntegrado.PrimeiroVencimento =  primeiroVencimento;

    this.novoProduto.Orcamentos = [];

    this.novoProduto.Orcamentos.push(this.orcamentoIntegrado);

    this.ps.adicionarProduto(this.novoProduto);

    this.createForm();
  }

  ngOnInit() {
  }

}
