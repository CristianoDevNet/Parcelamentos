import Produto from './Produto';
import Parcela from './Parcela';

export default class Orcamento 
{
    Id: number;

    ProdutoId: number;

    ValorBase: number;

    JurosMes: number;

    QtdParcelas: number;

    Produto: Produto;

    Parcelas: Parcela[];
}