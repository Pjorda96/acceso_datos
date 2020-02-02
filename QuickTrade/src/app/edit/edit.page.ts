import { Component, OnInit } from '@angular/core';
import {emptyElement, IData, IHogar, IInmobiliaria, IMotor, ITecnologia} from '../interfaces';
import {ToastController} from '@ionic/angular';
import {ElementService} from '../services/element.service';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.page.html',
  styleUrls: ['./edit.page.scss'],
})
export class EditPage implements OnInit {
  nombre: string;
  descripcion: string;
  categoria: string | undefined = undefined;
  tipoMotor: string;
  kilometros: number;
  metrosCuadrados: number;
  banos: number;
  habitaciones: number;
  localidad: string;
  estado: string;
  precio: number;
  user = 'pjorda96'; // obtener del login
  key: string;

  constructor(
      private activatedRoute: ActivatedRoute,
      private toastController: ToastController,
      private elementService: ElementService
  ) {}

  ngOnInit() {
    this.key = this.activatedRoute.snapshot.paramMap.get('id');
    const elem = this.elementService.getElement(this.key);

    elem.once('value').then(snapshot => {
      let value = snapshot.val();
      value = {
        ...value,
        id: snapshot.key,
      };
      this.nombre = value.nombre;
      this.descripcion = value.descripcion;
      this.categoria = value.categoria;
      this.tipoMotor = value.tipoMotor;
      this.kilometros = value.kilometros;
      this.metrosCuadrados = value.metrosCuadrados;
      this.banos = value.banos;
      this.habitaciones = value.habitaciones;
      this.localidad = value.localidad;
      this.estado = value.estado;
      this.precio = value.precio;
    });
  }

  async toast(message: string, color?: string): Promise<void> {
    const toast = await this.toastController.create({
      message,
      duration: 2000,
      color,
      showCloseButton: true,
    });
    await toast.present();
  }

  editar(): void {
    const esValido = this.nombre && this.descripcion && this.categoria && this.precio;
    let element: IData | IMotor | IInmobiliaria | ITecnologia | IHogar = {
      nombre: this.nombre,
      descripcion: this.descripcion,
      categoria: this.categoria,
      precio: this.precio,
      user: this.elementService.getUserkey(this.user),
    };

    if (this.categoria === 'tecnologia') {
      element = {
        ...element,
        estado: this.estado,
      };
    }

    if (this.categoria === 'motor') {
      element = {
        ...element,
        tipoMotor: this.tipoMotor,
        kilometros: this.kilometros,
      };
    }

    if (this.categoria === 'inmobiliaria') {
      element = {
        ...element,
        metros_cuadrados: this.metrosCuadrados,
        banos: this.banos,
        habitaciones: this.habitaciones,
        localidad: this.localidad,
      };
    }

    if (esValido) {
      this.elementService.putElement(element, this.key);
      this.toast('Elemento editado correctamente');
    } else {
      this.toast('Revisa los datos', 'danger');
    }
  }
}
