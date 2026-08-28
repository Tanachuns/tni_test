'use client'
import ProductTable from "@/components/ProductTable";
import { Stock } from "@/types/stock";
import React, { useEffect } from "react";

export default function Home() {
  const [stock, setStock] = React.useState<Stock[]>([]);
  useEffect(() => {
      try {
      fetch(process.env.NEXT_PUBLIC_API_URL + "/api/stock")
      .then((res) => res.json())
      .then((data) => {
        console.log(data);
        setStock(data);
      }
    );
    }catch (error) {
      console.error("Error fetching stock data:", error);
    }
  }, []);

  const addTocart = (cartId: number, item: number, amount: number) => {
     try {
      fetch(process.env.NEXT_PUBLIC_API_URL + "/api/cart/increase", {
        method: "PATCH",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
            "CartId":cartId,
            "ItemId":item,
            "Amount":amount
        }),
      }
      )
      .then((data) => {
        console.log(data);
      }
    );
    }catch (error) {
      console.error("Error fetching stock data:", error);
    }
  }
  console.log(stock);
  return (
   <>
   <div className="flex flex-col items-center justify-center min-h-screen py-2">
    <ProductTable  stocks={stock}  addTocart={addTocart} />
   </div>
   </>
  );
}
