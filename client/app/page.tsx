'use client'
import ProductTable from "@/components/ProductTable";
import { Stock } from "@/types/stock";
import React, { useEffect } from "react";

export default function Home() {
  const [stock, setStock] = React.useState<Stock[]>([]);
  const [cartId, setCartId] = React.useState<string|null>("0");
  useEffect(() => {
    setCartId(localStorage.getItem("cartId"));
    if(cartId!="0"){
       try {
      fetch(process.env.NEXT_PUBLIC_API_URL + "/api/cart/"+cartId)
      .then((res) => res.json())
      .then((data) => {
        console.log(data);
        if(data.isCheckedOut){
          localStorage.removeItem("cartId");
          setCartId("0");
        }
      }
    );
    }catch (error) {
      console.error("Error fetching stock data:", error);
    }
    }
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

  const addTocart = (item: number, amount: number) => {
     try {
      console.log("cartId", cartId, "item", item, "amount", amount);
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
      .then((res) => {
        if(res.status==400){
          alert("invalid amount")
        }
        return res.json()
      })
      .then((data) => {
        console.log(data);
        localStorage.setItem("cartId", data.id.toString());
        window.location.reload();
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
    <p className="text-lg font-bold text-left">Cart ID: {cartId!="0"?cartId:"New"}</p>
    <ProductTable  stocks={stock}  addTocart={addTocart} />
   </div>
   </>
  );
}
