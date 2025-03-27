// src/components/tables/ScienceTables/ScienceTablesOne.tsx
import { useState, useEffect} from 'react';
import { useNavigate } from "react-router-dom";
import {
  Table,
  TableBody,
  TableCell,
  TableHeader,
  TableRow,
} from "../../ui/table";
// @ts-ignore
import { fetchScienceData } from "../../../api/scienceAPI.js";


interface Science {
  id: number;
  tieuDe: string;
  ngonNgu: string;
  tacGia: null;
  loaiCongBo: string;
  chiMucKhoaHoc: string;
  namCongBo: string;
}

interface ErrorModel{
  message: string;
}


export default function ScienceTablesOne() {
  const [scienceData, setScienceData] = useState<Science[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const navigate = useNavigate();

  useEffect(() => {
    const loadFacultyData = async () => {
      try {
        const data = await fetchScienceData();//
        setScienceData(data);
      } catch (error) {
        const err = error as ErrorModel;
        setError(
          err.message || "Khong the tai du lieu tu API"
        );
        console.error(error);
      } finally {
        setLoading(false);
      }
    };

    loadFacultyData();
  }, []);

  if (loading) return <div className='text-gray-500'>"Đang tải dữ liệu ..."</div>
  if (error) return <div className='text-red-500'>{error}</div>

  const handleViewDetail = (id: number) => {
    console.log("Log: " + id);
    navigate(`/chi-tiet-cong-bo-kh`)
  };

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
                  TIÊU ĐỀ
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  NGÔN NGỮ
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
                  LOẠI CÔNG BỐ
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  CHỈ MỤC KHOA HỌC
                </TableCell>

                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  NĂM CÔNG BỐ
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
              {scienceData.map((science) => (
                <TableRow key={science.id}>
                  <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                    {science.id}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                    {science.tieuDe}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                    {science.ngonNgu}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    {science.tacGia}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    {science.loaiCongBo}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    {science.chiMucKhoaHoc}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    {science.namCongBo}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    <div className="flex items-center gap-2">
                      <button
                        className="text-blue-500 hover:text-blue-700"
                        onClick={() => handleViewDetail(science.id)}
                      >
                        Chi tiết
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