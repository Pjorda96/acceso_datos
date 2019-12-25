import {Injectable} from '@angular/core';
import { data } from '../../global/storage';
import {IData, IHogar, IInmobiliaria, IMotor, ITecnologia} from '../interfaces';

@Injectable()
export class ElementService {
  getElements(): (IMotor | IInmobiliaria | ITecnologia | IHogar)[] {
    return data;
  }

  getElement(id: number): (IMotor | IInmobiliaria | ITecnologia | IHogar) {
    return data.filter(el => el.id === id);
  }

  putElement(element: (IMotor | IInmobiliaria | ITecnologia | IHogar | IData)): void {
    data.push(element);
  }
}
