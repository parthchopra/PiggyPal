import Image from "next/image";

type KidHeaderProps = {
  readonly name: string;
  readonly avatarUrl: string;
  readonly balance: number;
};

export default function KidHeader({
  name,
  avatarUrl,
  balance,
}: Readonly<KidHeaderProps>) {
  return (
    <div className="flex items-center gap-4 mb-6">
      <Image
        src={avatarUrl}
        alt={name + " avatar"}
        width={64}
        height={64}
        className="rounded-full border-4 border-pink-200 shadow"
      />
      <div>
        <div className="text-xl font-bold text-gray-800">{name}</div>
        <div className="text-pink-600 font-semibold text-lg">
          <span className="text-2xl">💰</span> {balance} Bucks
        </div>
      </div>
    </div>
  );
}
