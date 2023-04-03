import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Categories } from 'src/app/models/categories';
import { CategoriesService } from 'src/app/services/categories.service';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmDialogComponent } from '../confirm-dialog/confirm-dialog.component';
import { Sort } from '@angular/material/sort';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.scss'],
})
export class CategoriesComponent implements OnInit {
  public categories: Categories[] = [];
  public loading: boolean = true;

  constructor(
    private categoriesService: CategoriesService,
    private dialog: MatDialog,
    private router: Router,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.getCategories();
  }

  getCategories() {
    this.categoriesService.get().subscribe({
      next: (categories) => {
        this.categories = categories;
      },
      error: (error) => {
        this.snackBar.open(
          'Error al obtener las categorías: ocurrió un error interno en el servidor',
          'Cerrar',
          { duration: 5000 }
        );
      },
      complete: () => {
        this.loading = false;
      },
    });
  }

  addCategory() {
    this.router.navigate(['/categories/add']);
  }

  editCategory(category: Categories) {
    this.router.navigate(['/categories/edit', category.ID]);
  }

  deleteCategory(category: Categories) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '300px',
      data: { message: '¿Estás seguro que deseas borrar esta categoría?' },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result === true) {
        this.categoriesService.delete(category.ID).subscribe({
          next: () => {
            this.snackBar.open('La categoría ha sido eliminada', 'Cerrar', {
              duration: 2000,
            });
            this.loading = true;
          },
          error: (error) => {
            let message = 'Error al eliminar la categoría';
            if (error.status === 404) {
              message += ': la categoría no fue encontrada';
            } else if (error.message === 'Internal Server Error') {
              message += ': ocurrió un error interno en el servidor';
            } else {
              message +=
                ': la categoría está siendo usada por una o más tablas';
            }
            this.snackBar.open(message, 'Cerrar', { duration: 5000 });
          },
          complete: () => {
            this.getCategories();
          },
        });
      }
    });
  }

  sortData(event: Sort): void {
    const sortColumn = event.active;
    const sortDirection = event.direction;
    this.categories = this.categories.slice().sort((a, b) => {
      const isAsc = sortDirection === 'asc';
      switch (sortColumn) {
        case 'id':
          return this.compare(a.ID, b.ID, isAsc);
        case 'categoryName':
          return this.compare(a.CategoryName, b.CategoryName, isAsc);
        case 'description':
          return this.compare(a.Description, b.Description, isAsc);
        default:
          return 0;
      }
    });
  }

  compare(a: number | string, b: number | string, isAsc: boolean): number {
    return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
  }
}
