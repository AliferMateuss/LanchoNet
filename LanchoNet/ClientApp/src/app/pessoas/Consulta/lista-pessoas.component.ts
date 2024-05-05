import { HttpClient, HttpParams } from '@angular/common/http';
import { ChangeDetectorRef, Component, Inject, ViewChild, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatPaginator, MatPaginatorIntl, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
@Component({
  selector: 'app-lista-pessoas',
  templateUrl: './lista-pessoas.component.html',
  styleUrls: ['./lista-pessoas.component.css']
})
export class ListaPessoasComponent {
  pessoa = new Pessoa();
  dataSource!: MatTableDataSource<Pessoa>;
  displayedColumns: string[] = ['nome', 'documento', 'tipoPessoa', 'Acoes'];
  tipos = new FormControl('');
  tiposPessoas: string[] = ['Cliente', 'Funcionário', 'Fornecedor'];
  ehFiltro = false;
  pagina = 1;


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
    return "";
  }

  ngOnInit() {
    this.carregarPessoas();
  }

  carregarPessoas() {
    const params = new HttpParams()
      .set('pagina', 1)
      .set('tamanhoPagina', 10);

    this.http.get<any>(this.baseUrl + "api/Pessoas/RecuperarPessoas", { params }).subscribe(data => {
      console.log(data)
      this.dataSource = new MatTableDataSource<Pessoa>();
      this.dataSource.data = data.listaPessoas;
      this.paginator.length = data.quantidade;
      this.paginator.page.subscribe(($event) => {
        this.carregarMaisPessoas($event);
      });
      this.dataSource.paginator = this.paginator;
    }, error => console.error(error));
  }

  formatarCpfCnpj(valor: string): string {
    // Remove caracteres não numéricos
    const valorLimpo = valor.replace(/\D/g, '');

    // Verifica se é CPF (11 dígitos) ou CNPJ (14 dígitos)
    if (valorLimpo.length === 11) {
      return valorLimpo.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, '$1.$2.$3-$4');
    } else if (valorLimpo.length === 14) {
      return valorLimpo.replace(/(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/, '$1.$2.$3/$4-$5');
    } else {
      // Retorna o valor original se não for CPF nem CNPJ
      return valor;
    }
  }


  ngAfterViewInit() {
  }

  filtrar() {
    this.pagina = 1;
    this.ehFiltro = this.verificaFiltro();
    this.http.post<Pessoa[]>(this.baseUrl + "api/Pessoas/RecuperarPessoas", { dto: this.pessoa, pagina: 1, tamanhoPagina: 10 }).subscribe(data => {
      this.dataSource.data = data;
    }, error => console.error(error));
  }

  carregarMaisPessoas(event: PageEvent) {
    let request;
    const pagina = event.pageIndex + 1;
    if (this.ehFiltro) {
      request = this.http.post<Pessoa[]>(this.baseUrl + "api/Pessoas/RecuperaPessoaPorFiltro", { dto: this.pessoa, pagina, tamanhoPagina: 10 });
    } else {
      const params = new HttpParams()
        .set('pagina', pagina.toString())
        .set('tamanhoPagina', '10');
      request = this.http.get<Pessoa[]>(this.baseUrl + "api/Pessoas/RecuperarPessoas", { params });
    }

    request.subscribe(
      data => {
        this.dataSource.data.push(...data);
      },
      error => {
        console.error(error);
      }
    );
  }

  excluirPessoa(id: number) {
    const params = new HttpParams().set('id', id);
    this.http.get(this.baseUrl + "api/Pessoas/Deletar", { params }).subscribe(data => {
      this.carregarPessoas();

    }, error => console.error(error));
  }

  verificaFiltro(): boolean {
    if (this.pessoa.nome !== null || this.pessoa.nome !== '')
      return false;

    if (this.pessoa.documento !== null || this.pessoa.documento !== '')
      return false;

    if (this.pessoa.cliente)
      return false;

    if (this.pessoa.funcionario)
      return false;

    if (this.pessoa.fornecedor)
      return false;

    return true;
  }

  montatipoPessoa(pessoa: Pessoa): string {
    var tipo: string[] = [];

    if (pessoa.cliente)
      tipo.push('Cliente');
    if (pessoa.fornecedor)
      tipo.push('Fornecedor');
    if (pessoa.funcionario)
      tipo.push('Funcionario');

    return tipo.join(' | ');
  }

}


class Pessoa {
  id?: number;
  nome?: string;
  documento?: string;
  cliente?: boolean;
  fornecedor?: boolean;
  funcionario?: boolean;
}

