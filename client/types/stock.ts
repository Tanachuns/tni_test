export type Stock = {
    id: number;
    itemId: number;
    item: {
        id: number;
        name: string;
        description: string | null;
        price: number;
        createdAt: string;
        updatedAt: string | null;
        isActive: boolean;
    };
    amount: number;
    createdAt: string;
    updatedAt: string | null;   
}
