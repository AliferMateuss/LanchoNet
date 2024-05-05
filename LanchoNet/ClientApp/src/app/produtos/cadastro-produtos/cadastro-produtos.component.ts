import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';

@Component({
  selector: 'app-cadastro-produtos',
  templateUrl: './cadastro-produtos.component.html',
  styleUrls: ['./cadastro-produtos.component.css']
})
export class CadastroProdutosComponent {
  produto: Produtos = new Produtos();
  formProduto?: FormGroup;
  imageUrl: string | ArrayBuffer | null = null;
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  ngAfterViewInit() {
    this.formProduto = new FormGroup({
      nome: new FormControl(this.produto.nome, [Validators.required]),
      quantidade: new FormControl(this.produto.quantidade, [Validators.required]),
      preco: new FormControl(this.produto.preco, [Validators.required]),
      precoCompra: new FormControl(this.produto.precoCompra, [Validators.required])
    }, [this.validacaoPrecos()]);
  }

  validacaoPrecos(): ValidatorFn {
    return (group: AbstractControl): ValidationErrors | null => {
      const preco = group.get('preco')?.value;
      const precoCompra = group.get('precoCompra')?.value;
      if (preco && precoCompra && preco <= precoCompra) {
        return { invalidComparison: true };
      }
      return null;
    };
  }

  salvarproduto() {
    if (this.formProduto?.invalid) {
      console.log(this.formProduto)
      console.log(this.formProduto.errors?.invalidComparison)
      const form = document.querySelector('.needs-validation') as HTMLFormElement;
      form.classList.add('was-validated');

      if (this.formProduto.errors?.invalidComparison) {
          var preco = document.querySelector('#precoCompra') as HTMLFormElement;
          preco.style.borderColor = 'var(--bs-form-invalid-color)';
          var input = document.querySelector('.invalid-feedback.preco') as HTMLFormElement;
          input.style.display = 'block';
      } else {
        var data = document.querySelector('#precoCompra') as HTMLFormElement;
          data.style.borderColor = 'var(--bs-border-color)';
        var input = document.querySelector('.invalid-feedback.preco') as HTMLFormElement;
          if (input)
            input.style.display = 'none';
      }
      return;
    } else {
      /*      this.http.post<any>(this.baseUrl + 'Produtos/Salvar', this.produto);*/
      console.log(this.produto)
      console.log(this.formProduto)
    }
  }

  onFileSelected(event: any): void {
    const file: File = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => {
        this.imageUrl = reader.result;
      };
      this.produto.imagem = file;
    } else {
      this.produto.imagem = null;
    }
  }

  dataURLtoFile(dataURL: string, filename: string): File {
    const arr = dataURL.split(',');
    const mime = arr[0].match(/:(.*?);/)?.[1];
    const bstr = atob(arr[1]);
    let n = bstr.length;
    const u8arr = new Uint8Array(n);
    while (n--) {
      u8arr[n] = bstr.charCodeAt(n);
    }
    return new File([u8arr], filename, { type: mime });
  }
}


class Produtos {
  nome: string | null = null;
  quantidade: number | null = null;
  preco: number | null = null;
  precoCompra: number | null = null;
  imagem: File | null = null;
}
