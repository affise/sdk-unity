platform :ios, '11.0'

target 'UnityFramework' do
   pod 'AffiseInternal', '1.6.20'
   
end

target 'Unity-iPhone' do
end

use_frameworks! :linkage => :static
