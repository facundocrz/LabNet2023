import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Shippers } from 'src/app/models/shippers';
import { ShippersService } from 'src/app/services/shippers.service';
import { noWhitespaceValidator } from 'src/app/validators/no-whitespace.validator';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'addShipper',
  templateUrl: './add-shipper.component.html',
  styleUrls: ['./add-shipper.component.scss'],
})
export class AddShipperComponent implements OnInit {
  public shipperForm: FormGroup = this.formBuilder.group({});
  public shipper: Shippers = new Shippers();

  constructor(
    private formBuilder: FormBuilder,
    private shipperService: ShippersService,
    private router: Router,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.shipperForm = this.formBuilder.group({
      companyName: ['', [Validators.required, noWhitespaceValidator()]],
      phone: '',
    });
  }

  onSubmit(): void {
    this.shipper = this.shipperForm.value;
    this.shipperService.add(this.shipper).subscribe({
      next: () => {
        this.router.navigate(['/shippers']);
        this.snackBar.open(
          'El transportista se ha agregado correctamente',
          'Cerrar',
          { duration: 5000 }
        );
      },
      error: (error) => {
        this.snackBar.open(
          `Error al agregar el transportista: ocurrió un error interno en el servidor`,
          'Cerrar',
          { duration: 5000 }
        );
      },
      complete: () => {},
    });
  }

  goBack(): void {
    this.router.navigate(['/shippers']);
  }
}
