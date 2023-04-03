import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Categories } from 'src/app/models/categories';
import { CategoriesService } from 'src/app/services/categories.service';
import { noWhitespaceValidator } from 'src/app/validators/no-whitespace.validator';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'editCategory',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.scss'],
})
export class EditCategoryComponent implements OnInit {
  public category: Categories = new Categories();
  public categoryForm: FormGroup = this.formBuilder.group({});

  constructor(
    private categoriesService: CategoriesService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private snackBar: MatSnackBar
  ) {
    this.categoryForm = this.formBuilder.group({
      categoryName: ['', [Validators.required, noWhitespaceValidator()]],
      description: [''],
    });
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.categoriesService.getById(+id).subscribe({
        next: (category) => {
          this.category = category;
          this.categoryForm.patchValue({
            categoryName: this.category.CategoryName,
            description: this.category.Description,
          });
        },
        error: (error) => {
          let message = 'Error al obtener la categoría';
          if (error.status === 404) {
            message += ': la categoría no fue encontrada';
          } else {
            message += ': ocurrió un error interno en el servidor';
          }
          this.snackBar.open(message, 'Cerrar', { duration: 5000 });
        },
        complete: () => {},
      });
    }
  }

  onSubmit(): void {
    this.category.CategoryName = this.categoryForm.value.categoryName;
    this.category.Description = this.categoryForm.value.description;
    this.categoriesService.update(this.category).subscribe({
      next: () => {
        this.router.navigate(['/categories']);
      },
      error: (error) => {
        this.snackBar.open(
          'Error al actualizar la categoría: ocurrió un error interno en el servidor',
          'Cerrar',
          { duration: 5000 }
        );
      },
      complete: () => {
        this.snackBar.open('Categoría actualizada exitosamente', 'Cerrar', {
          duration: 5000,
        });
      },
    });
  }

  cancel(): void {
    this.router.navigate(['/categories']);
  }

  goBack(): void {
    this.router.navigate(['/categories']);
  }
}
