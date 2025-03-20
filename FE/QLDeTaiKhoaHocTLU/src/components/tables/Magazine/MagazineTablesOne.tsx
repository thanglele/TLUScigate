import { useState, useEffect } from "react";
import {
  Table,
  TableBody,
  TableCell,
  TableHeader,
  TableRow,
} from "../../ui/table";
import { FiEye, FiEdit, FiTrash2 } from "react-icons/fi";
import { fetchTapChiAnPham } from "../../../api/MagazineAPI";

interface Magazine {
  id: number;
  name: string;
  category: string;
  author: string;
  country: string;
  year: string;
}

// Hàm chuẩn hóa dữ liệu từ API
const normalizeMagazineData = (data: any[]): Magazine[] => {
  return data.map((item, index) => ({
    id: index + 1, // Giả lập ID dựa trên index
    name: item.tenAnPham,
    category: item.loaiAnPham,
    author: "Không có dữ liệu", // API không cung cấp author, đặt giá trị mặc định
    country: item.quocGia,
    year: item.namXuatBan.toString(), // Chuyển số thành chuỗi
  }));
};

const handleViewDetail = (id: number) => {
  console.log(`Xem chi tiết ấn phẩm: ${id}`);
};

const handleEdit = (id: number) => {
  console.log("Sửa thông tin ấn phẩm:", id);
};

const handleDelete = (id: number) => {
  console.log("Xóa ấn phẩm:", id);
};

export default function MagazineTablesOne() {
  const [magazineData, setMagazineData] = useState<Magazine[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const loadMagazineData = async () => {
      try {
        const rawData = await fetchTapChiAnPham();
        const normalizedData = normalizeMagazineData(rawData);
        setMagazineData(normalizedData);
      } catch (err: any) {
        setError(
          err.message || "Không thể tải dữ liệu Tạp chí ấn phẩm từ API."
        );
        console.error(err);
      } finally {
        setLoading(false);
      }
    };

    loadMagazineData();
  }, []);

  if (loading) return <div className="text-gray-500">Đang tải dữ liệu...</div>;
  if (error) return <div className="text-red-500">{error}</div>;

  return (
    <div className="overflow-hidden rounded-xl border border-gray-200 bg-white dark:border-white/[0.05] dark:bg-white/[0.03]">
      <div className="max-w-full overflow-x-auto">
        <div className="min-w-[1102px]">
          <Table>
            <TableHeader className="border-b border-gray-100 dark:border-white/[0.05]">
              <TableRow>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  ID
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  TÊN ẤN PHẨM
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  LOẠI ẤN PHẨM
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  TÁC GIẢ
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  QUỐC GIA
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  NĂM XUẤT BẢN
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  HÀNH ĐỘNG
                </TableCell>
              </TableRow>
            </TableHeader>

            <TableBody className="divide-y divide-gray-100 dark:divide-white/[0.05]">
              {magazineData.map((magazine) => (
                <TableRow key={magazine.id}>
                  <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                    {magazine.id}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                    {magazine.name}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                    {magazine.category}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    {magazine.author}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    {magazine.country}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    {magazine.year}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    <div className="flex items-center gap-2">
                      <button
                        className="text-blue-600 hover:text-blue-900 transition-colors"
                        onClick={() => handleViewDetail(magazine.id)}
                      >
                        <FiEye className="w-4 h-4" />
                      </button>
                      <button
                        className="text-green-600 hover:text-green-900 transition-colors"
                        onClick={() => handleEdit(magazine.id)}
                      >
                        <FiEdit className="w-4 h-4" />
                      </button>
                      <button
                        className="text-red-600 hover:text-red-900 transition-colors"
                        onClick={() => handleDelete(magazine.id)}
                      >
                        <FiTrash2 className="w-4 h-4" />
                      </button>
                    </div>
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </div>
      </div>
    </div>
  );
}