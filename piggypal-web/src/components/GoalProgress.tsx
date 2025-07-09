type GoalProgressProps = {
  goalName: string;
  current: number;
  target: number;
};

export default function GoalProgress({
  goalName,
  current,
  target,
}: Readonly<GoalProgressProps>) {
  const percent = Math.min(100, Math.round((current / target) * 100));
  return (
    <div className="w-full mb-6">
      <h2 className="text-lg font-semibold text-gray-700 mb-2">
        Goal Progress
      </h2>
      <div className="mb-1 text-sm text-gray-600">{goalName}</div>
      <div className="w-full bg-gray-200 rounded-full h-4 mb-2">
        <div
          className="bg-green-400 h-4 rounded-full transition-all"
          style={{ width: percent + "%" }}
        ></div>
      </div>
      <div className="text-sm text-gray-700">
        {current} / {target} Bucks
      </div>
    </div>
  );
}
