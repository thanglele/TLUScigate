import React from 'react'
import Button from './Button'

const Form = ({children}) => {
  return (
    <div className="bg-white p-5 rounded-xl md:w-2/3 w-2/3 text-sm mx-auto">
        {children}
    </div>
  )
}

export default Form