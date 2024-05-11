import { HttpClient, HttpParams } from '@angular/common/http';
import { ChangeDetectorRef, Component, Inject, ViewChild } from '@angular/core';
import { MatPaginator, MatPaginatorIntl } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-lista-mesas',
  templateUrl: './lista-mesas.component.html',
  styleUrls: ['./lista-mesas.component.css']
})
export class ListaMesasComponent {
  dataSource!: MatTableDataSource<Mesa>;
  displayedColumns: string[] = ['numero', 'capacidade', 'acoes'];

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
    this.carregarMesas();
  }

  carregarMesas() {
    this.http.get<any>(this.baseUrl + "api/Mesa/RecuperarMesas").subscribe(data => {
      this.dataSource = new MatTableDataSource<Mesa>();
      this.dataSource.data = data;
      this.paginator.length = data.length;
      this.dataSource.paginator = this.paginator;
    }, error => console.error(error));
  }

  excluirMesa(id: number) {
    const params = new HttpParams().set('id', id);
    this.http.get(this.baseUrl + "api/Mesa/Deletar", { params }).subscribe(data => {
      this.carregarMesas();
    }, error => console.error(error));
  }
};

class Mesa {
  id!: number;
  numero!: number;
  capacidade!: number
}
