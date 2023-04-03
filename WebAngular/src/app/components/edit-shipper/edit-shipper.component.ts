import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Shippers } from 'src/app/models/shippers';
import { ShippersService } from 'src/app/services/shippers.service';
import { noWhitespaceValidator } from 'src/app/validators/no-whitespace.validator';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'editShipper',
  templateUrl: './edit-shipper.component.html',
  styleUrls: ['./edit-shipper.component.scss'],
})
export class EditShipperComponent implements OnInit {
  public shipper: Shippers = new Shippers();
  public shipperForm: FormGroup = this.formBuilder.group({});

  constructor(
    private shipperService: ShippersService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private snackBar: MatSnackBar
  ) {
    this.shipperForm = this.formBuilder.group({
      companyName: ['', [Validators.required, noWhitespaceValidator()]],
      phone: '',
    });
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.shipperService.getById(+id).subscribe({
        next: (shipper) => {
          this.shipper = shipper;
          this.shipperForm.patchValue({
            companyName: this.shipper.CompanyName,
            phone: this.shipper.Phone,
          });
        },
        error: (error) => {
          let message = 'Error al obtener el transportista';
          if (error.status === 404) {
            message += ': el transportista no fue encontrado';
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
    this.shipper.CompanyName = this.shipperForm.value.companyName;
    this.shipper.Phone = this.shipperForm.value.phone;
    this.shipperService.update(this.shipper).subscribe({
      next: () => {
        this.snackBar.open('Transportista actualizado con éxito', 'Cerrar', {
          duration: 5000,
        });
        this.router.navigate(['/shippers']);
      },
      error: (error) => {
        let message = 'Error al actualizar el transportista';
        if (error.status === 404) {
          message += ': el transportista no fue encontrado';
        } else {
          message += ': ocurrió un error interno en el servidor';
        }
        this.snackBar.open(message, 'Cerrar', { duration: 5000 });
      },
      complete: () => {},
    });
  }

  cancel(): void {
    this.router.navigate(['/shippers']);
  }

  goBack(): void {
    this.router.navigate(['/shippers']);
  }
}
