import { Component, OnInit } from '@angular/core';
import Produto from 'src/Models/Produto';
import { ProdutoService } from "../produto.service";
import Parcela from 'src/Models/Parcela';

@Component({
  selector: 'app-tela-inicial',
  templateUrl: './tela-inicial.component.html',
  styles: []
})
export class TelaInicialComponent implements OnInit {

  produtos: any;

  orcamentos: any;

  parcelas: Parcela[];

  parcelasTotal: number;

  constructor(private ps: ProdutoService) {
    this.ps.todosOsProdutos().subscribe(produtos => {
      this.produtos = produtos;
    });
  }

  carregarOrcamentos(event, produtoId) {
    event.preventDefault()

    this.ps.carregarOrcamentos(produtoId).subscribe(orcamentos => {
      this.orcamentos = orcamentos;

      this.parcelas = null;
    });
  }

  carregarParcelas(event, orcamentoId) {
    event.preventDefault()

    this.ps.carregarParcelas(orcamentoId).subscribe(parcelas => {
      this.parcelas = parcelas;

      this.parcelasTotal = 0;

      parcelas.forEach(p =>{
        this.parcelasTotal += p["valor"];
      });
    });
  }

  ngOnInit() {
  }

}
