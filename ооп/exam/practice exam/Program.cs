////calculator
using System;
using System.Net;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            Console.Write("IP: ");
            if (IPAddress.TryParse(Console.ReadLine(), out IPAddress? ip))
            {
                Console.Write("Mask: ");
                if (IPAddress.TryParse(Console.ReadLine(), out IPAddress? mask))
                {
                    long iIp = ip.Address;
                    long iMask = mask.Address;

                    long subnet = iIp & iMask;
                    long broadcast = subnet | (iMask ^ 0b_11111111_11111111_11111111_11111111);
                    long host = iIp & ~iMask;

                    Console.WriteLine($"\nNetwork ID: {new IPAddress(subnet).ToString()}");
                    Console.WriteLine($"Host ID: {new IPAddress(host).ToString()}");
                    Console.WriteLine($"Broadcast Address: {new IPAddress(broadcast).ToString()}");
                }
                else
                {
                    Console.WriteLine("\nInvalid mask address!");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid IP address!");
            }

            Console.ReadLine();
        }
    }
}

//validator
using System;
using System.Net;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            Console.Write("IP: ");
            if (IPAddress.TryParse(Console.ReadLine(), out IPAddress? ip))
            {
                Console.Write("Mask: ");
                if (IPAddress.TryParse(Console.ReadLine(), out IPAddress? mask))
                {
                    byte[] bMask = mask.GetAddressBytes();
                    byte checker = 0b_10000000;
                    bool changed = false;
                    bool different = false;
                    bool condition = true;

                    for (int i = 0; i < bMask.Length; i++)
                    {
                        if (!condition)
                        {
                            break;
                        }

                        checker = 0b_10000000;
                        for (int j = 0; j < 8; j++)
                        {
                            if (!different && changed)
                            {
                                condition = false;
                                break;
                            }

                            if ((bMask[i] & checker) == 0)
                            {
                                changed = true;
                                different = true;
                            }
                            else
                            {
                                different = false;
                            }

                            checker = (byte)(checker >> 1);
                        }
                    }

                    if (condition)
                    {
                        Console.WriteLine("\nIP address and mask are valid.");
                    }
                    else
                    {
                        Console.WriteLine("\nMask address is invalid.");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid mask address!");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid IP address!");
            }

            Console.ReadLine();
        }
    }
}
