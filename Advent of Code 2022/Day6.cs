using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022
{
    internal class Day6
    {
        //https://adventofcode.com/2022/day/6

        //static int markerSize = 4;
        static int markerSize = 14;

        static bool IsMarker(List<char> buffer)
        {
            for(int i = 0; i < buffer.Count; i++)
            {
                char currChar = buffer[i];
                for(int j = i+1; j < buffer.Count; j++) //Only checking the characters after us
                {
                    char nextChar = buffer[j];
                    if(currChar == nextChar)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void Run()
        {
            string input = "stftmtvvtvqqczqqnjnwwlqqdzdnnsvnsswbbwsstvvssfjsjbjfjmjpjzpplpppjzjqqdzzhqqqqtcccbzzzwzrrrdqdldpdsppmqmmnwwjddnqqscclncllvhllqpllchhbccfcbcgbcgcfcncsnstsddldzldlmljjfbjbzbccmrmrppqmqsswbwqwdwwcnwwhrhppfsfvsvrrfllhglhlggjpggzjgzggnvvqfvvhffpwpmwpmmwvmvrmrbmbzmzbbvgbbcfbcfbfppnzpzrrszzqgzgjgddmdwmwrmwmzznqzqhqhvvsslppsrrljjfpfcpfpbbrjjwjmjpmpfmfzfvzfftptzzbmzmddpvdddqmmzjzbbhmmwqmmmbgmmttrhrqrvqvzvdvzdvvmsvmmqlmmtddvlvttrtvtvcttvssnwwbccqmmgbbqrqlqjllmslsmslltrtffzfpfzpffvwvffsllgvgtgwtwnttfzznzqzztfzfvzznnwzzcvcqvvdwwsnsvnnthhnphpssmjmfmhfmhmgmllmsmrsrrmmhsswjwqqdbbghhpsptsswvsvfvcffqcchlhfhvhjhdjhddvjjpmmsrsqrrngrrmvmsvsllrmlrlprpggqzqmmvlvvwrwnrwwzztrzrbrdbrdbbhlhchjchhtthpthphplhhlphpjjsddtppvbpbbmnmgnmmqbbrhhfrfpfjpjgjljcctwtmwtwvvvmsvmmnjmnjmnmqmvvggtzzctzttszsvvjwjqjmjbjvbbshbhghlghhpvpnvvqmmgjmmggqvqtvqtvqtvvmlljbbhdhshnnwqwbbrnnwswmwfmfttjztjzjsjzjdjbdjjzfzdzgzhghgpgqqdzdhhnwnjnnhrnrqqjsqsllbzzzcnzzmjmvmrvrgrfgrrqmrmpmpzmzqqfwqfwfjjhphgpptzzwmmfjjvbjvbbqsbsbcbppjzpjjzpjpvjjzdjjgcgppvrvjrjpjspjppntpnnjlnlrnrdndjnnsbnnppvspprbrddjrdrmrfmmtmtbtntftjjsscvcbvvcnccnbnrbbmlmddhpdptddmrmmjddnjjtztctqqhhttqctqtbbnfnwnmndnzzljlgltgltljtjllwjjbrjbrbpbgppmzpmpggdnnmznnhhmfhhssgtgvvlsljltlppdqqbtbvbsvsswbsbhsbsmmwswbbbbhvbvcbvvsvcsvvmfmlmgmjgmmbqbrbsrrgrsggldlmlttpbpmmtptctqcqvccnhnmnssmvsmmddlclpccfwfdfqfvqfvfqqwmmwrmmbzznpnllfttgcttnbtnnsswttfppnddpdpsphhpttnrtrlrsrmrnmmzhmhnmnwwddmhdhqqhbqqdcclnlfnnzfnzzqfqddczcqcrrjsrrswslltfltffjhhqqfcchqcqpplbltbblbcbncnpccdffcwwqzwqqlwwtjjpbbjvvljvjgvvrsszfsfcssqsvvwsvvdfvdfdpffztzrtzthzhhmwmzwzssjlsldsldsldlvvjdvvnbvnvmvmccvfcvcfcbchhzqqhgqqcbbhdbdpddwcdwwzszsfszzgbgdgzgvgsgnssfqsqjssrppsgppmmpzmppglgqlqqpzpqqfzzzrnzrnrqqzzfwzzffjfzzmnznpznpprhhvcvvvfddcrdrsscnnsznzszbznntwntnrnbnzzrnnlwlggnzzwppmbmrrncnlclzltlblhhlvhvphhsdhsdsqddgzgvvshvvzzbvbrrlplqpptplljcljlvjlvlqvvndnsdddmvddzhzjjgpjpddppzllwtwfwgfgpffmhhzllsttmqqhjhhpvpgpfjsgscnwjmwmtmptwlpfjljwgpgntrlpjfgbjqmcpzgfhrwmznqnsbpptbdrzmdtvvtdqjgrjzlphndhmlchvddglqnqsjqrfqslprsvlqjwqnsmsznptsstpvdntpttslpmqqbsdlqwpjqnzmpblgqmjrvqwsncnzdszgfsghddlnwhwzpgtddgstttvrjfjwwfrgsdjjngljqlqcrzlgsmwngbzvmjwtnqdqcgwmfhsztgrtvvfzbtstmdbqpntdpsszjthqvpbdwswfzvmrcpbgbgdmldfhvdpfsmdzfhwsrpcglsztdwqgbqszcqtqjhgntzvttldqsffftzmllptzhmhpmfsgcchfrnrchnsgcfjbgrqmvrmmhnmlnwtgwhznqfgwnlrqlpjrvfrgzcjwncvlwhpclfzngbgvmrmlzngmqlvvwhbpjzlclgrcnnvnlppqhvlrnpzvmtsbdpfbwgffgzfwvltcfvfdcnfhwvcvclwwbmshhmpgrzgltwjmqczpqzdwfjpqhmwqhvvgnpgtwrjrgwvhthtdrdpnwpbmwstgblwmbfvlwflqmfbcsgwstwvncwfcsmrpcfrrvmlbqhdtdswswfnzhgzlngwsrtlzfcgdppmjnghfrgbdqhqmslhcqddjvsslsjwqqznttqjzdlghnsvqqtwrpfbzjgwnrhhvlnbqmnvcpblzgbzltnrhzpdwvbqbtmctbzgsdjfzswrbqbzgvwjlwtmgcllnmnwcljbhbplpvtgpgjftfrbgpgmhghnjcgjfqmsbqhbgtzbfzgwmfdsgfgmgzsbgdrszfhjttbvcqjzjgbqfgswlmrrhnmnfrptvjtlnvplgznsljzfzmhghlsccnqzflfnmbhshfprhclmtfptcmtnhrjgnngnqnczvcgzzlntftjsbgpgwzbnrhzzfqmznqnzfrvjzsmtpjbswzjlbgpfftzrzbfgdblpwscbqjfrfmfnhhlhjprtlzzvwnwzsnqhnmgwsdprnrblgbclzhthftqzdljspwdzwmwhfmdzmlvqsngppdfsjdprbrhffcvcvzztjjqcffwbrvpzvzfzhjvsfvsnrmjvqmjtrjbmbqsdtjgvtbbzzfmnmrrflgcdtljpmpvqvdbzgbmhjgccgdtplllctzqpfqnsztbwdbmqgfzrcddtmwrgmwsghcfpgqssdjrtqhtjfbpjvjdnzgvpzrhbrhrhcmpbglbbrvdltdpsrwjbjzftccwgnqmnlqlpjwrfdvmlgvgqznlvsmpzsmgjstvqbqpprzlsdndpfbmqcrfgvcfvlfhmpfnnqlcqlnbbgcrrrhbtzwnwmfrnrzvgmqlmqnmnzbwflwzcmncphjqztlrzvpztqhptmfsrppvvlzcfnlrwptgccsjjjscjcwnzssmbcvtzhnscgsbrchbqbrtdzllfvmqfwznfzpzmbfwcdsfhdlddnfbdgqbqjqzdtppshwcvvcjqstdgtgbhmlqlrfrhbvfsszsmbldmwfnfgnjptdslnzwcjgmvbnqcfzjmrslrlllplbhpjcnvzmvrfzwqhmbnrvpqnvcfncgfwqlvcwpwwljssfmswctcmhgtphvjdpfnnzznfbdjcsndrczlgdjhrnrltsgbtqmqcbwlthwcgsbvqbnntcznczpmlmblwdrlmzqdztwsgjthjwtfcpgwbczmdmhttzcwvdzhdfldmwnbnfdcjgvjhrfltjnjhqhzmzrlbncwdnlgshmqhpgsdwbvmvjsfgvgqzqjqdzqzmfmrncfdgrqfrnstvpqwtltnhgrmhgmmnwvlnsfmmbjrdmrnlgfgpqncdpqgvjltpghbgffdppdcfhdqhtvrdnfvcttlrqppfnqtmzpfgsnmjqfrgtbbdzzrccsrzgfjndlrnzqmjjtgldglcpzcrhwfplvdndjtzbpfbbbpfljqnlvrdzbrvczzwdrvzlmslbjsqgqdrltmhwcdpldqldlpctcbjmsvdwlfspzlpgrhdrvjtprcwrmszvzwmmjgvsbfcztmrdgrgshgtggpzszgqhwmhdzjmzsgqsfmqvcgqqwgprgvvqlbfhpwsfbjdqtcfnfhsgzthzhbpwggbnscqbnvcdprsbgllsrdcclqggfgfdrpqlqljfwpmzdhthpczcsqrrm";

            List<char> buffer = new List<char>();
            for (int i = 1; i <= input.Count(); i++)
            {
                char currentChar = input[i - 1];
                buffer.Add(currentChar);
                if (i > markerSize)
                {
                    buffer.RemoveAt(0);
                    if (IsMarker(buffer))
                    {
                        Console.WriteLine("Marker detected after character {0}! Current buffer: {1}", i, string.Concat(buffer));
                        break;
                    }
                }
                Console.WriteLine("Buffer after loading character {0}: {1}", i, string.Concat(buffer));
            }

        }
    }
}
