import {Injectable} from '@angular/core';
import {IData, IHogar, IInmobiliaria, IMotor, ITecnologia} from '../interfaces';
import {AngularFireDatabase} from '@angular/fire/database';

@Injectable()
export class ElementService {
  user = 'usuario2';

  constructor(
    private db: AngularFireDatabase,
  ) { }

  getElements(): firebase.database.Reference {
    return this.db.database.ref('elements');
  }

  getMyElements(): firebase.database.Query {
    const user = 'pjorda96'; // obtener del login
    const elements = this.db.database.ref('elements');
    const userkey = this.getUserkey(user);

    return elements.orderByChild('usuario').equalTo(this.user);
  }

  getElement(key: string): firebase.database.Reference {
    return this.db.database.ref('/elements/' + key);
  }

  addElement(element: IData | IMotor | IInmobiliaria | ITecnologia | IHogar): firebase.database.Reference {
    const dbRef = this.db.database.ref('elements');
    return dbRef.push(element);
  }

  putElement(element: (IMotor | IInmobiliaria | ITecnologia | IHogar | IData), key: string): void {
    const ref = this.db.database.ref('elements');
    ref.child(key).set(element)
        .catch(err => {
          throw Error(err);
        });
  }

  deleteElement(key): void {
    const ref = this.db.database.ref('elements');

    ref.child(key).remove()
        .catch(err => {
          throw Error(err);
        });
  }

  getUserkey(user = this.user): string {
    const elements = this.db.database.ref('usuarios').orderByChild('nombre').equalTo(user);

    elements.once('value', snapshot => { // TODO: change
      // console.log(snapshot.val());
      snapshot.forEach(child => {
        // console.log(child.key);
      });
    });

    return 'usuario2'; // TODO: do it real
  }
}
