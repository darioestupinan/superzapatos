import { IStore }  from '../typings/istore.model.d'

export class Store implements IStore {
    id: number;
    name: string;
    address: string;
    constructor() {
        this.id = 0;
        this.name = "";
        this.address = "";
    }
}