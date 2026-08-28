import { Cart } from '@/types/cart'
import { Stock } from '@/types/stock'
import React from 'react'

type Props = {
  cart  : Cart|null,
  removeFromcart:Function,
  clearcart:Function,
  checkout:Function
}

export default function CartTable({ cart, removeFromcart , clearcart, checkout }: Props) {
  
  return (
   <div className="overflow-x-auto">
    <div className="flex items-center justify-between"><h1 className="text-2xl font-bold">Cart Table</h1> <a href="/" className="link link-secondary">view stocks</a></div>
  <table className="table">
    {/* head */}
    <thead>
      <tr>
        <th>Name</th>
        <th>Price</th>
        <th>Amount</th>
        <th></th>
      </tr>
    </thead>
    <tbody>
      {cart?.carts.map((item) => (
        <tr key={item.id}>
          <td>{item.item?.id}</td>
          <td>{item.item?.name}</td>
          <td>{item.item?.price.toFixed(2)}</td>
          <td>{item.amount}</td>
          <td><button onClick={() => removeFromcart(item.item?.id || 0, 1)} className="btn btn-primary btn-sm">-</button></td>
          <td><button onClick={() => removeFromcart(item.item?.id || 0, item.amount)} className="btn btn-primary btn-sm">Remove from Cart</button></td>
        </tr>
      ))}
        
    </tbody>
  </table>
  <div className="flex gap-2">
        <button onClick={()=>clearcart()}  className="btn btn-danger btn-sm">Clear Cart</button>
        <button onClick={()=>checkout()} className="btn btn-success btn-sm">Checkout</button>
  </div>
</div>
  )
}