'use client'
import CartTable from "@/components/CartTable";
import { Cart } from "@/types/cart";
import React, { useEffect } from "react";

export default function Home() {
  const [cart, setCart] = React.useState<Cart|null>(null);
  useEffect(() => {
    
      try {
      fetch(process.env.NEXT_PUBLIC_API_URL + "/api/cart/2")
      .then((res) => res.json())
      .then((data) => {
        console.log(data);
        setCart(data);
      }
    );
    }catch (error) {
      console.error("Error fetching stock data:", error);
    }
  }, []);
  console.log(cart);
  return (
   <>
   <div className="flex flex-col items-center justify-center min-h-screen py-2">
    <CartTable  cart={cart}/>
   </div>
   </>
  );
}
