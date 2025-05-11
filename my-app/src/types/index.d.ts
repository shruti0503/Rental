import { LucideIcon } from "lucide-react";
import { AuthUser } from "aws-amplify/auth";

interface Tenants{
    id:string,
    CognitoId:AuthUser,
    name:string,
    email:string,
    phoneNumber:number
}

interface Manager extends Tenants{
    userRole: JsonObject | JsonPrimitive | JsonArray
}

type User= Tenants | Manager ;

export {User, Manager};
