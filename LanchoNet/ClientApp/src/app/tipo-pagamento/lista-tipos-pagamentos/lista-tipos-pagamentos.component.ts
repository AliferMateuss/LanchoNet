import { HttpClient, HttpParams } from '@angular/common/http';
import { ChangeDetectorRef, Component, Inject, ViewChild } from '@angular/core';
import { MatPaginator, MatPaginatorIntl } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-lista-tipos-pagamentos',
  templateUrl: './lista-tipos-pagamentos.component.html',
  styleUrls: ['./lista-tipos-pagamentos.component.css']
})
export class ListaTiposPagamentosComponent {
  dataSource!: MatTableDataSource<TipoPagamento>;
  displayedColumns: string[] = ['nome', 'juros', 'quantidadeParcelas', 'acoes'];

  @ViewChild('paginator') paginator!: MatPaginator;
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private cdr: ChangeDetectorRef, private matPaginatorIntl: MatPaginatorIntl) {
    this.matPaginatorIntl.itemsPerPageLabel = 'Itens por página:';
    this.matPaginatorIntl.nextPageLabel = 'Próxima página';
    this.matPaginatorIntl.previousPageLabel = 'Página anterior';
    this.matPaginatorIntl.firstPageLabel = 'Primeira página';
    this.matPaginatorIntl.lastPageLabel = 'Última página';
    this.matPaginatorIntl.getRangeLabel = this.rangeLabel.bind(this);
  }

  rangeLabel(page: number, pageSize: number, length: number): string {
    if (length === 0 || pageSize === 0) {
      return `0 de ${length}`;
    }
    length = Math.max(length, 0);
    const startIndex = page * pageSize;
    const endIndex = startIndex < length ? Math.min(startIndex + pageSize, length) : startIndex + pageSize;
    return `${startIndex + 1} - ${endIndex} de ${length}`;
  }

  ngOnInit() {
    this.carregarTiposPagamento();
  }

  carregarTiposPagamento() {
    this.http.get<any>(this.baseUrl + "api/TipoPagamento/RecuperarTiposPagamento").subscribe(data => {
      this.dataSource = new MatTableDataSource<TipoPagamento>();
      this.dataSource.data = data;
      this.paginator.length = data.length;
      this.dataSource.paginator = this.paginator;
    }, error => console.error(error));
  }

  excluirTipoPagamento(id: number) {
    const params = new HttpParams().set('id', id);
    this.http.get(this.baseUrl + "api/TipoPagamento/Deletar", { params }).subscribe(data => {
      this.carregarTiposPagamento();
    }, error => console.error(error));
  }
}

class TipoPagamento {
  id!: number;
  nome!: string;
  juros!: number | null;
  quantidadeParcelas!: number;
}
