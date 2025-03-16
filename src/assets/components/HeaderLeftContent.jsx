import React from 'react';
import '../../index.css';

const HeaderLeftContent = ({ value}) => {
  return (
    <div className="absolute left-10 top-10 font-extrabold text-white text-2xl font-vt323"
    >
      {value}
    </div>
  );
};

export default HeaderLeftContent;