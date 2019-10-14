import { Injectable } from '@angular/core';

import { HttpClient } from "@angular/common/http";
import Parcela from 'src/Models/Parcela';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  endPoint = "https://localhost:44390/api";

  constructor(private http: HttpClient) { }

  adicionarProduto(novoProduto) {
    console.log(novoProduto);

    this.http.post(`${this.endPoint}/produto`, novoProduto).subscribe(res => {
      alert('Produto cadastrado com sucesso');
    });
  }

  todosOsProdutos() {
    return this.http.get(`${this.endPoint}/produto`);
  }

  carregarOrcamentos(produtoId) {
    return this.http.get(`${this.endPoint}/orcamento/produto/${produtoId}`);
  }

  carregarParcelas(orcamentoId) {
    return this.http.get<Parcela[]>(`${this.endPoint}/parcela/orcamento/${orcamentoId}`);
  }
}
