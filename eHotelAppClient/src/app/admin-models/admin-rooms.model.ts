import { RoomFeature } from "./admin-room-feature.model";
import { RoomType } from "./admin-room-type.model";

export class AdminRoomsModel{
    id : string = "";
    roomName : string = "";
    Description: string = "";
    maxGuests: number = 0;
    minGuests: number = 0;
    maxChildren: number = 0;
    RoomFeatureId: string[] = [];
    RoomTypeId: string[] = [];
    roomType: string[] = [];
    floorNumber: number = 0;
    roomNumber: number = 0;
    roomCount : number = 0;
    isAvailable: boolean = false;                  
    price: number = 0;
}