export type Cart = {
    id: number;
    carts: {
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
        } | null;
        amount: number;
        createdAt: string;
        updatedAt: string | null;
    }[];
    isCheckedOut: boolean;
    createdAt: string;
    updatedAt: string | null;
}
