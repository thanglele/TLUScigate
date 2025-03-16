import React from 'react'

const FormHeader = ({value, className}) => {
  return (
    <div className="flex justify-between items-center mb-3">
      <h3 className={className}>{value}</h3>
      <img src="src/img/logo-dai-hoc-thuy-loi-inkythuatso.svg" alt="Logo" className="w-20 h-20" />
    </div>
  )
}

export default FormHeader