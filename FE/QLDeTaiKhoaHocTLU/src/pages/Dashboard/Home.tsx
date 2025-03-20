import { FaGraduationCap, FaBook, FaChartBar, FaUserGraduate, FaClipboardList } from "react-icons/fa";

export default function Home() {
  // Hàm Card đơn giản, nhận label và icon
  const Card = ({ label, icon }: { label: string; icon: React.ReactNode }) => {
    return (
      <div className="bg-blue-400 rounded-lg p-6 flex flex-col items-center justify-center h-60  hover:bg-blue-800 hover:shadow-lg transition-shadow">
        <div className="text-white text-4xl mb-2">{icon}</div>
        <p className="text-white text-lg font-medium">{label}</p>
      </div>
    );
  };

  return (
    <div className="grid grid-cols-12 gap-4 md:gap-20 p-6">
      {/* Hàng trên: 3 card */}
      <div className="col-span-12 grid grid-cols-3 gap-4 md:gap-6">
        <div className="col-span-1">
          <Card label="Cổng bảo khoa học" icon={<FaGraduationCap />} />
        </div>
        <div className="col-span-1">
          <Card label="Tập chí, ấn phẩm" icon={<FaBook />} />
        </div>
        <div className="col-span-1">
          <Card label="Đề tài nghiên cứu" icon={<FaChartBar />} />
        </div>
      </div>

      {/* Hàng dưới: 2 card so le, căn giữa 2 khe */}
      <div className="col-span-12 grid grid-cols-4 gap-4 md:gap-2">
        <div className="col-span-1 col-start-1"></div> {/* Khoảng trống bên trái */}
        <div className="col-span-1">
          <Card label="Giảng viên" icon={<FaUserGraduate />} />
        </div>
        <div className="col-span-1">
          <Card label="Báo cáo - thống kê" icon={<FaClipboardList />} />
        </div>
        <div className="col-span-1"></div> {/* Khoảng trống bên phải */}
      </div>
    </div>
  );
}