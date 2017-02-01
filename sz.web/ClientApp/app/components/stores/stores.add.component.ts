import { Component } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Article } from './models/article.model';
import { Store } from './models/store.model';
import { StoreService }  from './services/store.service';
import { FormsModule }   from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

@Component({
    selector: 'stores.add',
    templateUrl: './stores.add.component.html',
    providers: [StoreService]
})
export class StoresAddComponent {
    public stores: Store[];
    public newStore: Store = new Store();
    public submitted: boolean = false;

    constructor(private _service: StoreService) {        
    }

    onSubmit() {
        this.submitted = true;
        this._service.saveStore(this.newStore).subscribe(result => {
            this.newStore = result.json().store;
        });
    }

    createNewStore() {
        this.newStore = new Store();
    }
}