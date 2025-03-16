import React from "react";

const FooterBoard = ({ year }) => {
  return (
    <div className="bg-blue-950 text-white p-1 flex justify-between items-center bottom-0 h-40">
      <img
        src="src/img/Screenshot 2025-03-16 at 16.57.37.png"
        alt="logo"
        className="object-fit h-40 w-70"
      />
      <div className="mr-40">
        <p className="text-xl font-bold mr-30">TRƯỜNG ĐẠI HỌC THỦY LỢI</p>
        <p className="text-xs">
          Địa chỉ: 175 Tây Sơn, Đống Đa, Hà Nội
          <br />
          Điện thoại: (024) 38522201 - Fax: (024) 35633351
          <br />
          Email: phongtchc@tlu.edu.vn
        </p>
      </div>
      <p className="text-xs mt-1 mr-20"> {year} TRƯỜNG ĐẠI HỌC THỦY LỢI</p>
    </div>
  );
};

export default FooterBoard;
