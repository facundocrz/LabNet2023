import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Shippers } from 'src/app/models/shippers';
import { ShippersService } from 'src/app/services/shippers.service';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmDialogComponent } from '../confirm-dialog/confirm-dialog.component';
import { Sort } from '@angular/material/sort';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'shippers',
  templateUrl: './shippers.component.html',
  styleUrls: ['./shippers.component.scss'],
})
export class ShippersComponent implements OnInit {
  public shippers: Shippers[] = [];
  public loading: boolean = true;

  constructor(
    private shippersService: ShippersService,
    private dialog: MatDialog,
    private router: Router,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.getShippers();
  }

  getShippers() {
    this.shippersService.get().subscribe({
      next: (shippers) => {
        this.shippers = shippers;
      },
      error: (error) => {
        this.snackBar.open(
          'Error al obtener los transportistas: ocurrió un error interno en el servidor',
          'Cerrar',
          { duration: 5000 }
        );
      },
      complete: () => {
        this.loading = false;
      },
    });
  }

  addShipper() {
    this.router.navigate(['/shippers/add']);
  }

  editShipper(shipper: Shippers) {
    this.router.navigate(['/shippers/edit', shipper.ID]);
  }

  deleteShipper(shipper: Shippers) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '300px',
      data: { message: '¿Estás seguro que deseas borrar este transportista?' },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result === true) {
        this.shippersService.delete(shipper.ID).subscribe({
          next: () => {
            this.snackBar.open('El transportista ha sido eliminado', 'Cerrar', {
              duration: 5000,
            });
            this.getShippers();
          },
          error: (error) => {
            this.snackBar.open(
              'Error al eliminar el transportista: ocurrió un error interno en el servidor',
              'Cerrar',
              { duration: 5000 }
            );
          },
        });
      }
    });
  }

  sortData(sort: Sort) {
    const data = this.shippers.slice();
    if (!sort.active || sort.direction === '') {
      this.shippers = data;
      return;
    }

    this.shippers = data.sort((a, b) => {
      const isAsc = sort.direction === 'asc';
      switch (sort.active) {
        case 'CompanyName':
          return this.compare(a.CompanyName, b.CompanyName, isAsc);
        case 'Phone':
          return this.compare(a.Phone, b.Phone, isAsc);
        default:
          return 0;
      }
    });
  }

  compare(a: number | string, b: number | string, isAsc: boolean) {
    return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
  }
}
