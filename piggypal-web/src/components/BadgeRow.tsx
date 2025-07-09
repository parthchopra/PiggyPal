import Image from "next/image";

type Badge = {
  id: number;
  name: string;
  iconUrl: string;
};

type BadgeRowProps = {
  readonly badges: Badge[];
};

export default function BadgeRow({ badges }: Readonly<BadgeRowProps>) {
  return (
    <div className="w-full mb-6">
      <h2 className="text-lg font-semibold text-gray-700 mb-2">
        Badges Earned
      </h2>
      {badges.length === 0 ? (
        <div className="text-gray-400 italic">
          No badges earned yet. Keep going!
        </div>
      ) : (
        <div className="flex flex-row gap-4 items-center">
          {badges.map((badge) => (
            <div key={badge.id} className="flex flex-col items-center">
              <Image
                src={badge.iconUrl}
                alt={badge.name}
                width={40}
                height={40}
                className="mb-1"
              />
              <span className="text-xs text-gray-600">{badge.name}</span>
            </div>
          ))}
        </div>
      )}
    </div>
  );
}
