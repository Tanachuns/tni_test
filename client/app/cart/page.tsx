'use client'
import CartTable from "@/components/CartTable";
import { Cart } from "@/types/cart";
import React, { useEffect } from "react";

export default function Home() {
  const [cart, setCart] = React.useState<Cart|null>(null);
  const [cartId, setCartId] = React.useState<string|null>("new");
  useEffect(() => {
    console.log("cartId", localStorage.getItem("cartId"));
    setCartId(localStorage.getItem("cartId")||"new");
    if(cartId!="new"){
       try {
      fetch(process.env.NEXT_PUBLIC_API_URL + "/api/cart/"+cartId)
      .then((res) => res.json())
      .then((data) => {
        console.log(data);
        if(data.isCheckedOut){
          localStorage.removeItem("cartId");
          alert("Cart is already checked out");
          window.location.href="/";
        }
      }
    );
    }catch (error) {
      console.error("Error fetching stock data:", error);
    }
    try {
      fetch(process.env.NEXT_PUBLIC_API_URL + "/api/cart/" + cartId)
      .then((res) => res.json())
      .then((data) => {
        console.log(data);
        setCart(data);
      }
    );
    }catch (error) {
      console.error("Error fetching stock data:", error);
    }
    }
      
  }, [cartId]);
  console.log(cart);

const removeFromcart = ( item: number, amount: number) => {
     try {
      console.log("cartId", cartId, "item", item, "amount", amount);
      fetch(process.env.NEXT_PUBLIC_API_URL + "/api/cart/decrease", {
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
        alert("Item removed from cart successfully");
        window.location.reload();
      }
    );
    }catch (error) {
      console.error("Error fetching stock data:", error);
    }
  }

  const clearcart = ( ) => {
    
     try {
   
      fetch(process.env.NEXT_PUBLIC_API_URL + "/api/cart/clear/" + cartId, {
        method: "PATCH",
        headers: {
          "Content-Type": "application/json",
        },
        
      }
      )
      .then((data) => {
        console.log(data);
        alert("Cart cleared successfully");
        window.location.reload();
      }
    );
    }catch (error) {
      console.error("Error fetching stock data:", error);
    }
  }

  const checkout = ( ) => {
     try {
   
      fetch(process.env.NEXT_PUBLIC_API_URL + "/api/cart/checkout/" + cartId, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
      }
      ).then((res)=>{
        if(!res.ok){
          alert("Checkout failed!")
        window.location.href = "/"

        }else{
          return res.json()
        }
      })
      .then((data) => {
        console.log(data);
        alert(`cart: ${data.cartId} Total: ${data.total}`)
        window.location.href = "/"
      }
    );
    }catch (error) {
      console.error("Error fetching stock data:", error);
    }
  } 
 

  return (
   <>
   <div className="flex flex-col items-center justify-center min-h-screen py-2">
    <p className="text-lg font-bold text-left">Cart ID: {cartId}</p>
    <CartTable  cart={cart} removeFromcart={removeFromcart} clearcart={clearcart} checkout={checkout}/>
   </div>
   </>
  );
}
