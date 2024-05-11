import { HttpClient, HttpParams } from '@angular/common/http';
import { ChangeDetectorRef, Component, Inject, ViewChild } from '@angular/core';
import { MatPaginator, MatPaginatorIntl } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-lista-usuarios',
  templateUrl: './lista-usuarios.component.html',
  styleUrls: ['./lista-usuarios.component.css']
})
export class ListaUsuariosComponent {
  dataSource!: MatTableDataSource<Usuario>;
  displayedColumns: string[] = ['usuario', 'grupoUsuario', 'Acoes'];

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
    this.carregarUsuarios();
  }

  carregarUsuarios() {

    this.http.get<Usuario[]>(this.baseUrl + "api/Usuario/RecuperarUsuarios").subscribe(data => {
      this.dataSource = new MatTableDataSource<Usuario>();
      this.dataSource.data = data;
      this.dataSource.paginator = this.paginator;
    }, error => console.error(error));
  }

  excluirUsuario(id: number) {
    const params = new HttpParams().set('id', id);
    this.http.get(this.baseUrl + "api/Usuario/Deletar", { params }).subscribe(data => {
      this.carregarUsuarios();

    }, error => console.error(error));
  }
}

class Usuario {

  id!: number;
  usuario!: string;
/*  grupoNome!: string;*/
}
