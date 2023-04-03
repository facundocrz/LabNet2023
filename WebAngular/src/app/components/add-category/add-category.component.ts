import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Categories } from 'src/app/models/categories';
import { CategoriesService } from 'src/app/services/categories.service';
import { noWhitespaceValidator } from 'src/app/validators/no-whitespace.validator';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'addCategory',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.scss'],
})
export class AddCategoryComponent implements OnInit {
  public categoryForm: FormGroup = this.formBuilder.group({});
  public category: Categories = new Categories();

  constructor(
    private formBuilder: FormBuilder,
    private categoryService: CategoriesService,
    private router: Router,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.categoryForm = this.formBuilder.group({
      categoryName: ['', [Validators.required, noWhitespaceValidator()]],
      description: '',
    });
  }

  onSubmit(): void {
    this.category = this.categoryForm.value;
    this.categoryService.add(this.category).subscribe({
      next: () => {
        this.router.navigate(['/categories']);
        this.snackBar.open(
          'La categoría se ha agregado correctamente',
          'Cerrar',
          { duration: 5000 }
        );
      },
      error: (error) => {
        this.snackBar.open(
          `Error al agregar la categoría: ocurrió un error interno en el servidor`,
          'Cerrar',
          { duration: 5000 }
        );
      },
      complete: () => {},
    });
  }

  goBack(): void {
    this.router.navigate(['/categories']);
  }
}
