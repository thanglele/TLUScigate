import React from "react";
import MenuItem from "./MenuItem";
import TodoDown from "./TodoDown";
import UserMenuItem from "./UserMenuItem";

const SideBarLeft = () => {
  return (
    <div className="w-64 h-screen bg-white shadow-md flex flex-col p-3">

     <TodoDown />

      <div className="p-4 flex items-center ml-10">
        <img
          src="src/img/logo-dai-hoc-thuy-loi-inkythuatso.svg"
          alt="Logo"
          className="w-30 h-30"
        />
      </div>

      <div className="flex-1">
        <MenuItem icon="🏠" label="Trang chủ" isActive={true} />
        <MenuItem icon="👨‍🏫" label="Giảng viên" />
        <MenuItem icon="📚" label="Đề tài nghiên cứu" />
        <MenuItem icon="🏫" label="Công bố khoa học" />
        <MenuItem icon="📊" label="Tạp chí, ấn phẩm" />
        <MenuItem icon="📈" label="Báo cáo - thống kê" />
      </div>

     <UserMenuItem />
    </div>
  );
};

export default SideBarLeft;
