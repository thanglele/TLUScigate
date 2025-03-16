import React from "react";
import Card from "./Card";

const MainContent = () => {
  return (
    <div className="flex-1 flex p-20 bg-gray-50">
      <div className="flex-1 grid grid-cols-1 md:grid-cols-3 gap-10">
      <Card icon={"👨‍🏫"} label="Giảng viên" />
      <Card icon={"📈"} label="Đề tài nghiên cứu" />
        <Card icon={"🏫"} label="Công bố khoa học" />
        <Card icon={"📊"} label="Tạp chí, ấn phẩm" />
        <Card icon={"📊"} label="Báo cáo - thống kê" />
      </div>
    </div>
  );
};

export default MainContent;
