import { Injectable } from '@angular/core';

import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  endPoint = "https://localhost:44390/api";
  
  constructor(private http: HttpClient) { }

  adicionarProduto(NomeProduto)
  {
    const obj = 
    {
      NomeProduto
    };

    console.log(obj);

    this.http.post(`${this.endPoint}/produto`, obj).subscribe(res => console.log('Done'));
  }
}
