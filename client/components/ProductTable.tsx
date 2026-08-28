import { Stock } from '@/types/stock'
import React from 'react'

type Props = {
  stocks: Stock[],
  addTocart:Function
}

export default function ProductTable({ stocks, addTocart }: Props) {
  
  return (
   <div className="overflow-x-auto">
    <div className="flex items-center justify-between"><h1 className="text-2xl font-bold">ProductTable</h1> <a href="/cart" className="link link-secondary">view cart</a></div>
  <table className="table">
    {/* head */}
    <thead>
      <tr>
        <th></th>
        <th>Name</th>
        <th>price</th>
        <th>Stocks</th>
        <th></th>
      </tr>
    </thead>
    <tbody>
      {stocks.map((stock) => (
        <tr key={stock.id}>
          <th>{stock.id}</th>
          <td>{stock.item.name}</td>
          <td>₹{stock.item.price.toFixed(2)}</td>
          <td>{stock.amount}</td>
          <td><button onClick={() => addTocart(2, stock.id, 1)} className="btn btn-primary btn-sm">Add to Cart</button></td>
        </tr>
      ))}
    </tbody>
  </table>
</div>
  )
}